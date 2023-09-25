import React from 'react';
import cls from './Input.module.scss';

const Input = ({ placeholder }) => {
  return (
    <>
      <input
        type="text"
        placeholder={placeholder}
        className={cls.input}
      />
    </>
  );
};

export default Input;
