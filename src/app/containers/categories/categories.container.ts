import { Component, OnInit } from "@angular/core";
import { CategoryService } from '../../services/category.service';
import { CategoryModel } from "../../models/categoryModel";
import { Router } from "@angular/router";

@Component({
    selector: 'categories-container',
    templateUrl: 'categories.container.html'
})

export class CategoriesContainer implements OnInit{

    constructor(
        private categoryService: CategoryService,
        private router: Router
    ){}

    categories: CategoryModel[] = [];

    ngOnInit(): void {
        this.categoryService.GetAllCategories().subscribe(x => this.categories = x);
    }

    getQuestions(category: string){
        this.router.navigate(['questions', category]);
    }
}