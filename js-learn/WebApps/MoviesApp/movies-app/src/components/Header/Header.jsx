import React from 'react';
import Button from '../../UI/Button/Button';
import Input from '../../UI/Input/Input';
import Container from '../Container/Container';
import './Header.scss';

const Header = () => {
  return (
    <header className="header">
      <Container>
        <h1>MovieApp</h1>
        <Input placeholder="Search..." />
        <Button>Random movie</Button>
      </Container>
    </header>
  );
};

export default Header;
