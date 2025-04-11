export interface AuthContextData {
  token: string;
  isAuthenticated: boolean;
  storeTokenToLocalStorage: (token: string) => void;
}
