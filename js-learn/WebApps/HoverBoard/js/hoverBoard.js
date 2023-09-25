export class HoverBoard {
  constructor(options) {
    this.options = options;
  }

  colors = [
    '#9B6AD6',
    '#8643D6',
    '#512882',
    '#679FD2',
    '#FFC200',
    '#A67E00'
  ];

  create() {
    this.board = document.createElement('table');
    this.board.classList.add('hover-board');

    for (let i = 0; i < this.options.rows; i++) {
      this.board.append(this.createRow());
    }

    this.options.container.append(this.board);
  }

  createRow() {
    let row = document.createElement('tr');
    row.classList.add('hover-board-row');

    for (let i = 0; i < this.options.cols; i++) {
      row.append(this.createCell());
    }

    return row;
  }

  createCell() {
    let cell = document.createElement('td');
    cell.classList.add('hover-board-cell');
    cell.addEventListener('mouseover', this.setColor.bind(this));
    cell.addEventListener('mouseout', this.removeColor.bind(this));
    return cell;
  }

  setColor(event) {
    let color =
      this.colors[this.getRandomNumber(0, this.colors.length - 1)];

    event.target.style.background = color;

    event.target.style.boxShadow = `0 0 2px ${color}, 0 0 20px ${color}`;
  }

  removeColor(event) {
    event.target.style.background = '';
    event.target.style.boxShadow = '';
  }

  getRandomNumber(min, max) {
    if (min > max) {
      [min, max] = [max, min];
    }

    return Math.floor(min + Math.random() * (max + 1 - min));
  }
}

let board = new HoverBoard({
  rows: 60,
  cols: 60,
  container: document.querySelector('.container')
});

board.create();
