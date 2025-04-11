import { createContext } from 'react';
import { AuthContextData } from '../interfaces/auth-context-data.interface';

export const AuthContext = createContext<AuthContextData | null>(null);
