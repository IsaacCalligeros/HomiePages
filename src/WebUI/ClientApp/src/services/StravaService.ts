import axiosInstance from "../axiosInstance";

export class StravaService {
    GetAuthUrl = async () => {
    const res: string = await (
      await axiosInstance.get(`api/Strava/GetAuthUrl`)
    ).data;
    return res;
  };

  setAuthCode = async (code: string) => {
    const res: string = await (
      await axiosInstance.post(`api/Strava/SetAuthCode?code=${code}`)
    ).data;
    return res;
  };

  GetActivity = async () => {
    const res: string = await (
      await axiosInstance.get(`api/Strava/GetActivity`)
    ).data;
    return res;
  };
}
