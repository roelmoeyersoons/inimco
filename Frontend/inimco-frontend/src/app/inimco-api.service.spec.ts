import { TestBed } from '@angular/core/testing';

import { InimcoAPIService } from './inimco-api.service';

describe('InimcoAPIService', () => {
  let service: InimcoAPIService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(InimcoAPIService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
