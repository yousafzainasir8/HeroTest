import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Response, BrandViewModel } from '../models/app.models';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BrandsService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getBrandList(): Observable<Response<BrandViewModel[]>> {
    return this.http.get<Response<BrandViewModel[]>>(`${this.baseUrl}brands`);
  }

}
