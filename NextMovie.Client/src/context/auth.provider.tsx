import { useEffect, useState } from 'react';
import { AuthContext } from './auth.context';
import { Constants } from '../Constants';
import { jwtDecode } from 'jwt-decode';

// eslint-disable-next-line @typescript-eslint/no-unused-vars
export const AuthProvider = ({ children }) => {
  const [token, setToken] = useState(
    localStorage.getItem(Constants.JWT_TOKEN_KEY) || ''
  );
  const [isAuthenticated, setIsAuthenticated] = useState(false);

  useEffect(() => {
    if (token && !isTokenExpired(token)) {
      setIsAuthenticated(true);
    } else {
      setIsAuthenticated(false);
      setToken('');
      localStorage.removeItem(Constants.JWT_TOKEN_KEY);
    }
  }, [token]);

  const isTokenExpired = (token: string) => {
    if (!token) {
      return true;
    }

    const decoded = jwtDecode(token);
    if (!decoded.exp) {
      return true;
    }

    const expirationDate = new Date(0);
    expirationDate.setUTCSeconds(decoded.exp);

    return expirationDate < new Date();
  };

  const storeTokenToLocalStorage = (newToken: string) => {
    if (newToken) {
      setToken(newToken);
      localStorage.setItem(Constants.JWT_TOKEN_KEY, newToken);
    } else {
      setToken('');
      localStorage.removeItem(Constants.JWT_TOKEN_KEY);
    }
  };
  return (
    <AuthContext.Provider
      value={{
        token: token ? token : '',
        isAuthenticated: isAuthenticated,
        storeTokenToLocalStorage,
      }}
    >
      {children}
    </AuthContext.Provider>
  );
};
