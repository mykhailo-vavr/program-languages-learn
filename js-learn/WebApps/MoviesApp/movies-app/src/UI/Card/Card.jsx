import React from 'react';
import cls from './Card.module.scss';

const Card = ({ name }) => {
  return (
    <div className={cls.card}>
      <div className={cls.image}></div>
      <div className={cls.description}>{name}</div>
    </div>
  );
};

export default Card;
