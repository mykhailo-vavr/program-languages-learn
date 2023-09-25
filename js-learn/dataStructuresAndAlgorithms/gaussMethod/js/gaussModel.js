import { gaussView as view } from './gaussView.js';

export let gaussModel = {
  getCoefs() {
    this.coefs = [];
    let inputs = document.querySelectorAll('[type = "number"]');
    let value = +document.querySelector('#list').value;
    this.value = value; // to get permission on getResult()

    for (let i = 0, all = 0; i < value; i++) {
      let tempArr = [];
      for (let j = 0; j < value + 1; j++, all++) {
        let value = +inputs[all].value;

        if (value) {
          tempArr.push(value);
        } else {
          tempArr.push(0);
        }
      }
      this.coefs.push(tempArr);
    }
  },

  reduceToSteppedAppearance() {
    let coefs = this.coefs;

    for (let i = 0; i < coefs.length - 1; i++) {
      this.getSimplifyRow(i, coefs);
      view.showSolutionStep(coefs);
      for (let j = 1; j < coefs.length; j++) {
        // to avoid subtracting identical rows
        if (i != j) {
          this.getDifferenceOfRows(i, j, coefs);
        }
        view.showSolutionStep(coefs);
      }
    }
  },

  // divide all row by its first none zero element
  getSimplifyRow(i, coefs) {
    let divider = coefs[i][i];

    if (divider == 0) return;

    for (let j = 0; j < coefs[i].length; j++) {
      coefs[i][j] /= divider;
      coefs[i][j] = +coefs[i][j].toFixed(10);
    }
  },

  // multiplied the row by multer
  getMultipliedRow(multer, row) {
    for (let num of row) {
      num *= multer;
    }
  },

  // row[i] - row[j]
  getDifferenceOfRows(i, j, coefs) {
    if (coefs[j][i] < 0) {
      this.getMultipliedRow(-1, coefs[j]);
    }

    if (coefs[i][i] < 0) {
      this.getMultipliedRow(-1, coefs[i]);
    }

    let multer = coefs[j][i];
    for (let k = 0; k < coefs[j].length; k++) {
      coefs[j][k] = coefs[i][k] * multer - coefs[j][k];
    }
  },

  getSolutions() {
    let solutions = [];
    let coefs = this.coefs;
    for (let i = coefs.length - 1; i >= 0; i--) {
      this.calculateRowSolution(coefs[i], solutions, i);
    }
    view.showSolutions(solutions);
  },

  calculateRowSolution(row, solutions, rowNum) {
    let solution = row[row.length - 1];

    for (let i = 0; i < solutions.length; i++) {
      solution -=
        +row[row.length - i - 2].toFixed(10) *
        +solutions[solutions.length - 1 - i].toFixed(10);
    }

    solution = row[rowNum] == 0 ? 0 : solution / row[rowNum];
    solutions.unshift(+solution.toFixed(5));
  },

  onClick() {
    view.clearTextArea();
    this.getCoefs();
    this.reduceToSteppedAppearance();
    this.getSolutions();
  },
};
