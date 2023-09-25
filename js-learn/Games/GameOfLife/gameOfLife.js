const CELLS = 100;

class View {
  constructor(options) {
    this.options = options;
  }

  createField() {
    let field = document.createElement('table');
    field.classList.add('field');
    field.style.width = `${this.options.width}px`;
    field.style.height = `${this.options.height}px`;

    for (let i = 0; i < CELLS; i++) {
      let row = document.createElement('tr');
      for (let j = 0; j < CELLS; j++) {
        let cell = document.createElement('td');
        cell.setAttribute('data-coords', `${i}-${j}`);
        row.append(cell);
      }
      field.append(row);
    }

    this.field = field;
    this.options.container.append(field);
  }

  paintCell(x, y) {
    let cell = document.querySelector(`[data-coords='${x}-${y}']`);
    cell.classList.add('painted-cell');
  }

  eraseCell(x, y) {
    let cell = document.querySelector(`[data-coords='${x}-${y}']`);
    cell.classList.remove('painted-cell');
  }
}

class Model {
  constructor(options, view) {
    this.options = options;
    this.view = view;
  }

  createField() {
    let field = [];
    for (let i = 0; i < CELLS; i++) {
      let row = [];
      for (let j = 0; j < CELLS; j++) {
        row.push(0);
      }
      field.push(row);
    }

    this.field = field;
  }

  changeConfig() {
    let nextStepField = this.getNextStepField();

    for (let i = 0; i < this.field.length; i++) {
      for (let j = 0; j < this.field[i].length; j++) {
        let countOfNeighbors = this.getCountOfNeighbors(i, j);

        if (this.field[i][j] === 0 && countOfNeighbors === 3) {
          nextStepField[i][j] = 1;
          this.view.paintCell(i, j);
        } else if (
          this.field[i][j] === 1 &&
          countOfNeighbors !== 2 &&
          countOfNeighbors !== 3
        ) {
          nextStepField[i][j] = 0;
          this.view.eraseCell(i, j);
        }
      }
    }

    this.field = nextStepField;
  }

  getCountOfNeighbors(y, x) {
    let count = 0;

    for (let i = y - 1; i <= y + 1; i++) {
      for (let j = x - 1; j <= x + 1; j++) {
        if ((i !== y || j !== x) && this.field[i] !== undefined) {
          if (this.field[i][j] === 1) {
            count++;
          }
        }
      }
    }
    return count;
  }

  getNextStepField() {
    let nextStepField = [];
    for (let i = 0; i < this.field.length; i++) {
      nextStepField.push(this.field[i].slice());
    }
    return nextStepField;
  }
}

class GameOfLife {
  constructor(options) {
    this.view = new View(options);
    this.model = new Model(options, this.view);
  }
  start() {
    this.view.createField();
    this.model.createField();
    this.setListeners();
  }

  setListeners() {
    this.boundOnClick = this.onClick.bind(this);
    this.view.field.addEventListener('click', this.boundOnClick);
    document.addEventListener('keypress', event => {
      if (event.code !== 'Space') {
        return;
      }
      this.view.field.removeEventListener('click', this.boundOnClick);
      this.startIteration();
    });
  }

  onClick({ target }) {
    let coords = target.dataset.coords;
    if (!coords) {
      return;
    }
    let [y, x] = coords.split('-');
    this.view.paintCell(y, x);
    this.model.field[y][x] = 1;
  }

  startIteration() {
    console.log(this.model.field);

    setInterval(this.model.changeConfig.bind(this.model), 100);
    console.log(this.model.field);
  }
}

let game = new GameOfLife({
  width: 500,
  height: 500,
  container: document.querySelector('.container')
});

game.start();
// let a = game.model.getCountOfNeighbors(2, 2);
// console.log(game.model.field);
// console.log(a);
