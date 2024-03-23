import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Response, HeroListViewModel, HeroViewModel } from '../models/app.models';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HeroesService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getHeroesForList(): Observable<Response<HeroListViewModel[]>> {
    return this.http.get<Response<HeroListViewModel[]>>(`${this.baseUrl}heroes`);
  }

  getHeroById(heroId: number): Observable<Response<HeroViewModel>> {
    return this.http.get<Response<HeroViewModel>>(`${this.baseUrl}heroes/${heroId}`);
  }

  addHero(hero: HeroViewModel): Observable<Response<boolean>> {
    return this.http.post<Response<boolean>>(`${this.baseUrl}heroes`, hero);
  }

  updateHero(hero: HeroViewModel): Observable<Response<boolean>> {
    return this.http.put<Response<boolean>>(`${this.baseUrl}heroes`, hero);
  }

  deleteHero(heroId: number): Observable<Response<boolean>> {
    return this.http.delete<Response<boolean>>(`${this.baseUrl}heroes/${heroId}`);
  }
}
