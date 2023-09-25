import React from 'react';
import Container from '../Container/Container';
import MainRow from '../MainRow/MainRow';
import './Main.scss';

const Main = () => {
  const films = [
    {
      name: 'film1'
    },
    {
      name: 'film2'
    },
    {
      name: 'film3'
    },
    {
      name: 'film4'
    },
    {
      name: 'film5'
    },
    {
      name: 'film6'
    }
  ];

  return (
    <section className="main">
      <Container>
        <MainRow title="Top 2021" films={films} />
        <MainRow title="Comedy" films={films} />
        <MainRow title="Action" films={films} />
        <MainRow title="Horror" films={films} />
      </Container>
    </section>
  );
};

export default Main;
