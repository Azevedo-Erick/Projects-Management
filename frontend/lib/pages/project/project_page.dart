import 'package:flutter/material.dart';
import 'package:frontend/controllers/project_controller.dart';
import 'package:frontend/pages/project/project_binding.dart';
import 'package:get/get.dart';

import '../../widgets/custom_app_bar_widget.dart';

class ProjectPage extends StatefulWidget {
  final int id;
  const ProjectPage({super.key, required this.id});

  @override
  State<ProjectPage> createState() => _ProjectPageState();
}

class _ProjectPageState extends State<ProjectPage> {
  late final ProjectController _projectController;

  @override
  void initState() {
    super.initState();
    setupProject();

    _projectController = Get.find<ProjectController>();
    _projectController.getProject(id: widget.id);
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: CustomAppBarWidget(
          name: 'Sobre o Projeto',
          body: Container(
              // Conteúdo do corpo da AppBar
              ),
        ),
        body: Obx(() {
          if (_projectController.isLoading.value) {
            return const CircularProgressIndicator();
          }
          if (_projectController.project == null) {
            return const Center(
              child: Text(
                "Projeto não encontrado",
              ),
            );
          }
          return Container(
            child: Text(_projectController.project!.name),
          );
        }));
  }
}
