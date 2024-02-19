import { TestBed } from '@angular/core/testing';
import { CinemaService } from './cinema.service';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

describe('CinemaService', () => {
  let service: CinemaService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [CinemaService]
    });
    service = TestBed.inject(CinemaService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

});