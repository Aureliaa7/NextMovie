import axios from 'axios';
import { Constants } from '../Constants';

const axiosInstance = axios.create({
  baseURL: 'https://localhost:7047/api/v1/', //TODO: extract
  headers: {
    'Content-Type': 'application/json',
  },
});

axiosInstance.interceptors.request.use(
  (config) => {
    if (!config.url?.includes('/login') && !config.url?.includes('/register')) {
      const token = localStorage.getItem(Constants.JWT_TOKEN_KEY);
      if (token) {
        config.headers['Authorization'] = `Bearer ${token}`;
      }
    }
    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);

export default axiosInstance;
