import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { CategoryModel } from "../models/categoryModel";

@Injectable()
export class CategoryService{
    private readonly categoryUrl = 'http://localhost:5026/api/category';

    constructor(protected http: HttpClient){}

    public GetAllCategories() : Observable<CategoryModel[]>{
        return this.http.get<CategoryModel[]>(`${this.categoryUrl}/all`);
    }
}