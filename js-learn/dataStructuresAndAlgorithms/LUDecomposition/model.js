import { view } from './view.js';

export let model = {
  getMatrix() {
    this.A = [];
    let inputs = document.querySelectorAll('[type = "number"]');
    let size = +document.querySelector('#list').value;
    this.size = size;

    for (let i = 0, all = 0; i < size; i++) {
      let tempArr = [];
      for (let j = 0; j < size; j++, all++) {
        let value = +inputs[all].value;

        if (value) {
          tempArr.push(value);
        } else {
          tempArr.push(0);
        }
      }
      this.A.push(tempArr);
    }
  },

  decomposite() {
    this.createLUMatrices();

    for (let i = 0; i < this.size; i++) {
      for (let j = 0; j < this.size; j++) {
        if (i <= j) {
          this.U[i][j] = this.A[i][j] - this.getSum(i, j);
        } else {
          this.L[i][j] =
            (this.A[i][j] - this.getSum(i, j)) / this.U[j][j];
        }
      }
    }

    view.showMatrix(this.L, 'L');
    view.showMatrix(this.U, 'U');
  },

  createLUMatrices() {
    let L = [];
    let U = [];

    for (let i = 0; i < this.size; i++) {
      L.push(new Array(this.size));
      U.push(new Array(this.size));
      for (let j = 0; j < this.size; j++) {
        U[i][j] = 0;
        if (i == j) {
          L[i][j] = 1;
        } else {
          L[i][j] = 0;
        }
      }
    }
    this.L = L;
    this.U = U;
  },

  getSum(i, j) {
    let sum = 0;
    for (let k = 0; k < i; k++) {
      sum += this.L[i][k] * this.U[k][j];
    }

    return sum;
  },

  onClick() {
    view.clearTextArea();
    this.getMatrix();
    this.decomposite();
    console.log(this.L);
    console.log(this.U);
  },
};
