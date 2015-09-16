import {Component, View, bootstrap} from 'angular2/angular2';

@Component({
  selector: 'my-component'
})
@View({
  template: `<div>Hello, {{message}}</div>`
})
export class MyComponent {
  message : string;
  constructor() {
    this.message = 'World';
  }
}