import axios from "axios";
import authService from "./components/api-authorization/AuthorizeService";

const publicUrl = new URL(process.env.PUBLIC_URL, window.location);
const instance = axios.create({
  baseURL: publicUrl.origin,
});

instance.interceptors.request.use(
  async (config) => {
    const token = await authService.getAccessToken();
    config.headers = {
      Authorization: `Bearer ${token}`,
      Accept: "application/json",
      ContentType: "application/json",
    };
    return config;
  },
  (error) => {
    Promise.reject(error);
  }
);

export default instance;
