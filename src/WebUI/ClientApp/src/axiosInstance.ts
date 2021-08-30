import axios from "axios";
import authService, { AuthenticationResultStatus } from "./components/api-authorization/AuthorizeService";

const location = window.location.toString();
const publicUrl = new URL(process.env.PUBLIC_URL, location);

const instance = axios.create({
  baseURL: process.env.BROWSER_SIDE_URL,
  httpsAgent: true
});

const login = async () => {
  const result = await authService.signIn(process.env.BROWSER_SIDE_URL);
  switch (result.status) {
      case AuthenticationResultStatus.Success:
          break;
      case AuthenticationResultStatus.Fail:
          //Navigate to login
          break;
      default:
          throw new Error(`Invalid status result ${result.status}.`);
  }
}

// const refreshAuthLogic = (failedRequest: any) => login().then(tokenRefreshResponse => {
//     return Promise.resolve();
// });

// createAuthRefreshInterceptor(axios, refreshAuthLogic);

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

instance.interceptors.response.use(response => {
  return response;
}, error => {
 if (error.response.status === 401) {
  login();
 }
});

export default instance;
