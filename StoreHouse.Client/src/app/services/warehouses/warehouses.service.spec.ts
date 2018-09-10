import { TestBed, inject } from '@angular/core/testing';

import { WarehousesService } from './warehouses.service';

describe('WarehousesService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [WarehousesService]
    });
  });

  it('should be created', inject([WarehousesService], (service: WarehousesService) => {
    expect(service).toBeTruthy();
  }));
});
