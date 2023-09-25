import { SliderModel } from './sliderModel.js';
import { SliderView } from './sliderView.js';

export class SliderController {
  constructor(options) {
    new Promise((res) => {
      this.view = new SliderView(options);
      res();
    }).then(() => {
      this.model = new SliderModel(
        this.view.header,
        this.view.gallery
      );
    });
  }

  create() {
    this.view.create();
  }
}
