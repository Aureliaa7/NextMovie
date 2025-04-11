import { useContext } from 'react';

import { AuthContextData } from '../interfaces/auth-context-data.interface';
import { AuthContext } from '../context/auth.context';

const useAuth = (): AuthContextData => {
  const context: AuthContextData | null = useContext(AuthContext);
  if (!context) throw new Error('Missing authentication provider!');
  return context;
};

export default useAuth;
