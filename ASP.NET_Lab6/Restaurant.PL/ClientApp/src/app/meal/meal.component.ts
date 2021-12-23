import {Component} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {DataService} from "../data.service";
import {Ingredient} from "./ingredient";

@Component({
  selector: 'app-meal',
  templateUrl: './meal.component.html',
})
export class MealComponent {
  id: number;
  ingredients: Ingredient[];

  constructor(private dataService: DataService, private route: ActivatedRoute) {
    this.route.params.subscribe(params => {
      this.id = params['id']
    })
    this.dataService.getMealIngredients(this.id).subscribe(data => this.ingredients = data);
  }
}
