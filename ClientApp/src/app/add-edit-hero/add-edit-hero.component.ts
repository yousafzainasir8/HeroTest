import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HeroesService } from '../services/heroes.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BrandsService } from '../services/brands.service';
import { BrandViewModel } from '../models/app.models';

@Component({
  selector: 'app-add-edit-hero',
  templateUrl: './add-edit-hero.component.html',
  styleUrls: ['./add-edit-hero.component.css']
})
export class AddEditHeroComponent implements OnInit {
  heroForm: FormGroup;
  isEditMode = false;
  brands: BrandViewModel[] = []
  constructor(
    private fb: FormBuilder,
    private heroesService: HeroesService,
    private route: ActivatedRoute,
    private toastr: ToastrService,
    private router: Router,
    private brandsService: BrandsService
  ) {
    this.heroForm = this.fb.group({
      Id: [0],
      Name: [null, Validators.required],
      Alias: [null, Validators.required],
      BrandId: [null, Validators.required]
    });
  }

  get name() { return this.heroForm.get('Name'); }
  get alias() { return this.heroForm.get('Alias'); }
  get brandId() { return this.heroForm.get('BrandId'); }

  ngOnInit(): void {
    const heroId = this.route.snapshot.params['id']; // Assuming your route is something like 'heroes/edit/:id'
    if (heroId) {
      this.isEditMode = true;
      this.getHeroById(heroId);
    }
    this.getBrandList();
  }

  getBrandList() {
    this.brandsService.getBrandList().subscribe(res => {
      if (res.IsSuccess && res.Data) {
        this.brands = res.Data;
      }
    })
  }

  getHeroById(heroId: number) {
    this.heroesService.getHeroById(heroId).subscribe({
      next: (response) => {
        if (response.IsSuccess && response.Data) {
          this.heroForm.patchValue({
            Id: response.Data.Id,
            Name: response.Data.Name,
            Alias: response.Data.Alias,
            BrandId: response.Data.BrandId
          });
        }
      },
      error: (error) => {
        console.error('Failed to fetch hero data', error);
      }
    });
  }

  onSubmit(): void {

    if (this.heroForm.valid) {
      const heroData = this.heroForm.value;
      if (this.isEditMode) {
        this.heroesService.updateHero(heroData).subscribe({
          next: () => {
            this.toastr.success('Hero updated successfully!', 'Success')
            this.router.navigate(['/']);
          },
          error: (error) => this.toastr.success('Update failed', 'Error')
        });
      } else {
        this.heroesService.addHero(heroData).subscribe({
          next: () => {
            this.toastr.success('Hero Added successfully!', 'Success')
            this.router.navigate(['/']);
          },
          error: (error) => this.toastr.success('Addition failed', 'Error')
        });
      }
    } else {
      this.heroForm.markAllAsTouched();
    }
  }
}
