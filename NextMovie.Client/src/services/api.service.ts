import axiosInstance from './axios-instance.service';

const get = async (url: string, config = {}) => {
  try {
    const response = await axiosInstance.get(url, config);
    return response.data;
  } catch (error) {
    console.error('Error in GET request:', error);
    throw error;
  }
};

// eslint-disable-next-line @typescript-eslint/no-explicit-any
const post = async (url: string, data: any, config = {}) => {
  try {
    const response = await axiosInstance.post(url, data, config);
    return response.data;
  } catch (error) {
    console.error('Error in POST request:', error);
    throw error;
  }
};

export const ApiService = {
  get,
  post,
};
