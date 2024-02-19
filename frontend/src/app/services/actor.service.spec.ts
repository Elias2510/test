import { TestBed } from '@angular/core/testing';
import { ActorService } from './actor.service';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

describe('ActorService', () => {
  let service: ActorService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [ActorService]
    });
    service = TestBed.inject(ActorService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

});