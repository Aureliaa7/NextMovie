import { AuthResult } from '../interfaces/account/auth-result.interface';
import { LoginData } from '../interfaces/account/login-data.interface';
import { UserCreationData } from '../interfaces/account/user-creation-data.interface';
import { ApiService } from './api.service';

const register = (userData: UserCreationData) => {
  return ApiService.post('users/register', userData);
};

const login = (loginData: LoginData): Promise<AuthResult> => {
  return ApiService.post('users/login', loginData);
};

export const UserService = {
  register,
  login,
};
