import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssessmentTaskComponent } from './assessment-task.component';

describe('AssessmentTaskComponent', () => {
  let component: AssessmentTaskComponent;
  let fixture: ComponentFixture<AssessmentTaskComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AssessmentTaskComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AssessmentTaskComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
