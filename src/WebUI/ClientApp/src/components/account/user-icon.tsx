import React from "react";
import styles from '../../CSS/_user-icon.module.scss'

interface UserIconProps {
    userName: string | null;
}

const UserIcon = (props: UserIconProps) => {
  return (
      <>
        {
          props.userName !== null && <div className={styles.UserIcon}>{props.userName[0]}</div>
        }
      </>
  );
};

export { UserIcon };
