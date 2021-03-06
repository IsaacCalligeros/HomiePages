import React from "react";
import { PushSpinner } from "react-spinners-kit";

interface LoadingProps {
  loading: boolean;
}

const Loading = (props: LoadingProps) => {
  return (
      <PushSpinner size={30} color="#686769" loading={props.loading} />
  );
};

export { Loading };
