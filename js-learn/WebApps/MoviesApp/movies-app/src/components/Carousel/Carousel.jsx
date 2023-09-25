import React, { useState } from 'react';
import cls from './Carousel.module.scss';
import CarouselItem from './CarouselItem';

const Carousel = ({ films }) => {
  const [position, setPosition] = useState(0);
  const itemWidth = 250;
  const countOfItems = films.length;

  const moveLeft = () => {
    const tempPosition = position + itemWidth;
    if (tempPosition > 0) {
      return;
    }
    setPosition(tempPosition);
  };

  const moveRight = () => {
    const tempPosition = position - itemWidth;

    if (
      tempPosition <
      -itemWidth * (countOfItems + tempPosition / itemWidth)
    ) {
      return;
    }
    setPosition(tempPosition);
  };

  return (
    <div className={cls.carousel}>
      <span
        className={`${cls.arrow} ${cls['arrow-left']}`}
        onClick={moveLeft}
      ></span>
      <span
        className={`${cls.arrow} ${cls['arrow-right']}`}
        onClick={moveRight}
      ></span>
      <ul className={cls.gallery} style={{ marginLeft: position }}>
        {films.map(({ name }) => {
          return (
            <CarouselItem
              className={cls.item}
              key={name}
              name={name}
            />
          );
        })}
      </ul>
    </div>
  );
};

export default Carousel;
