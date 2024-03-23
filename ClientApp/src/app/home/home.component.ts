import { Component, OnInit } from '@angular/core';
import { HeroesService } from '../services/heroes.service';
import { HeroListViewModel } from '../models/app.models';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  heroes: HeroListViewModel[] = [];

  constructor(private heroesService: HeroesService,
    private toastr: ToastrService,
  ) {

  }

  ngOnInit(): void {
    this.getHeroesForListView();
  }

  getHeroesForListView() {
    this.heroesService.getHeroesForList().subscribe(res => {
      if (res.IsSuccess && res.Data)
        this.heroes = res.Data;
    });
  }

  onDelete(id: number) {
    this.heroesService.deleteHero(id).subscribe(res => {
      if (res.IsSuccess && res.Data) {
        this.toastr.success("Hero deleted successfully","Success")
        this.getHeroesForListView();
      }
    });
  }
}
