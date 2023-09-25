import React from 'react';
import Carousel from '../Carousel/Carousel';
import cls from './MainRow.module.scss';

const MainRow = ({ films, title }) => {
  return (
    <div className={cls.row}>
      <h1 className={cls.title}>{title}</h1>
      <Carousel films={films} />
    </div>
  );
};

export default MainRow;
