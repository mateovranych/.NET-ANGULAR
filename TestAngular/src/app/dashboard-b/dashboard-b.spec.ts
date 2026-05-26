import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardB } from './dashboard-b';

describe('DashboardB', () => {
  let component: DashboardB;
  let fixture: ComponentFixture<DashboardB>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DashboardB]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DashboardB);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
