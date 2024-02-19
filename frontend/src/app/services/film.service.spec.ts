import { TestBed } from '@angular/core/testing';
import { FilmService } from './film.service';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

describe('FilmService', () => {
  let service: FilmService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [FilmService]
    });
    service = TestBed.inject(FilmService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

});