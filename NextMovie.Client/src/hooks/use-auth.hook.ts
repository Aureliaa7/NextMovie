import { useState, useEffect } from 'react';
import { jwtDecode } from 'jwt-decode';
import { Constants } from '../Constants';

const useAuth = () => {
  const [token, setToken] = useState(
    localStorage.getItem(Constants.JWT_TOKEN_KEY) || null
  );
  const [isAuthenticated, setIsAuthenticated] = useState(false);

  useEffect(() => {
    if (token && !isTokenExpired(token)) {
      setIsAuthenticated(true);
    } else {
      setIsAuthenticated(false);
      setToken(null);
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
      setToken(null);
      localStorage.removeItem(Constants.JWT_TOKEN_KEY);
    }
  };

  return { token, isAuthenticated, storeTokenToLocalStorage };
};

export default useAuth;
