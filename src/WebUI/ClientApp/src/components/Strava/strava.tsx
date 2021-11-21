import React, { useState } from "react";
import { useEffect } from "react";
import OauthPopup from "react-oauth-popup";
import { StravaService } from "../../services/StravaService";

interface StravaProps {
    containerId: number;
  }

const Strava = (props: StravaProps) => {
    const service = new StravaService();
    const [authUrl, setAuthUrl] = useState("");

    useEffect(() => {
        service.GetAuthUrl().then((res) => {
            setAuthUrl(res);
        });
    }, []);

    const onCode = (code: string, params: URLSearchParams) => {
        service.setAuthCode(code).then(() => {
          service.GetActivity();
        });
      }

      const onClose = () => console.log("closed!");

  return (
    <>
        <OauthPopup
          url={authUrl}
          onCode={(code, params) => onCode(code, params)}
          onClose={onClose}
          title={'Strava'}
          width={800}
          height={800}
        >
          <div>Click me to open a Popup</div>
        </OauthPopup>
        </>
  );
};

export { Strava };
