import {Component} from '@angular/core';
import {DataService} from "../data.service";

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
})
export class OrderComponent {

  constructor(private dataService: DataService) {
  }
}
