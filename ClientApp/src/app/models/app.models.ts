export interface Response<T> {
    Data: T | null;
    IsSuccess: boolean;
    Message: string;
}

export interface HeroListViewModel {
    Id: number;
    Name: string;
    Alias: string;
    Brand: string;
}

export interface HeroViewModel {
  Id: number;
  Name: string;
  Alias: string;
  BrandId: number;
}

export interface BrandViewModel {
  Id: number;
  Name: string;
}
