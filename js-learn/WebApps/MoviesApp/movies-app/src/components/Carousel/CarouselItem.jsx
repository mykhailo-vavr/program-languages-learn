import React from 'react';
import cls from './CarouselItem.module.scss';

const CarouselItem = ({ name }) => {
  return (
    <li className={cls.item}>
      <div className={cls.image}></div>
      <div className={cls.description}>{name}</div>
    </li>
  );
};

export default CarouselItem;
