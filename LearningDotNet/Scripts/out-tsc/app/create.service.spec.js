import { TestBed, inject } from '@angular/core/testing';
import { CreateService } from './create.service';
describe('CreateService', function () {
    beforeEach(function () {
        TestBed.configureTestingModule({
            providers: [CreateService]
        });
    });
    it('should be created', inject([CreateService], function (service) {
        expect(service).toBeTruthy();
    }));
});
//# sourceMappingURL=create.service.spec.js.map