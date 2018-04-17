import { TestBed, inject } from '@angular/core/testing';

import { QuoterService } from './quoter.service';

describe('QuoterService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [QuoterService]
    });
  });

  it('should be created', inject([QuoterService], (service: QuoterService) => {
    expect(service).toBeTruthy();
  }));
});
