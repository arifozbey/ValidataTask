import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KendouiComponent } from './kendoui.component';

describe('KendouiComponent', () => {
  let component: KendouiComponent;
  let fixture: ComponentFixture<KendouiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ KendouiComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(KendouiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
