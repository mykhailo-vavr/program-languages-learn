import React from 'react';
import cls from './Button.module.scss';

const Button = ({ children }) => {
  return (
    <>
      <button className={cls.button}>{children}</button>
    </>
  );
};

export default Button;
