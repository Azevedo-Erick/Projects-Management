import 'package:frontend/data/models/project_model.dart';
import 'package:frontend/data/repositories/project_repository.dart';
import 'package:get/get.dart';

class ProjectController extends GetxController {
  ProjectController({required this.projectRepository});

  final ProjectRepository projectRepository;

  ProjectModel? _project;
  ProjectModel? get project => _project;

  final RxBool _isLoading = false.obs;
  RxBool get isLoading => _isLoading;

  getProject({required int id}) async {
    _isLoading.value = true;

    final result = await projectRepository.getProject(id: id);
    _project = result;

    _isLoading.value = false;
  }
}
