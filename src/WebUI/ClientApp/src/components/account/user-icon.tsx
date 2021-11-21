import React from "react";
import '../../CSS/user-icon.scss'

interface UserIconProps {
    userName: string | null;
}

const UserIcon = (props: UserIconProps) => {
  return (
      <>
        {
          props.userName !== null && <div className="userIcon">{props.userName[0]}</div>
        }
      </>
  );
};

export { UserIcon };
