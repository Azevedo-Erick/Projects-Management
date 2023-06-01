import 'package:flutter/material.dart';
import 'package:frontend/pages/project/project_page.dart';
import 'package:frontend/pages/projects/projects_binding.dart';
import 'package:get/get.dart';

import '../../controllers/projects_controller.dart';
import '../../widgets/custom_app_bar_widget.dart';

class ProjectsPage extends StatefulWidget {
  const ProjectsPage({super.key});

  @override
  State<ProjectsPage> createState() => _ProjectsPageState();
}

class _ProjectsPageState extends State<ProjectsPage> {
  late final ProjectsController _projectsController;

  @override
  void initState() {
    super.initState();
    setupProjects();
    _projectsController = Get.find<ProjectsController>();
    _projectsController.getProjects();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: CustomAppBarWidget(
        name: 'Projetos',
        body: Container(
            // Conteúdo do corpo da AppBar
            ),
      ),
      body: Obx(() {
        if (_projectsController.isLoading.value) {
          return const CircularProgressIndicator();
        }
        if (_projectsController.projects.isEmpty) {
          return const Center(
            child: Text(
              "Não há projetos cadastrados",
            ),
          );
        }

        return ListView.separated(
            itemBuilder: (context, index) => GestureDetector(
                onTap: () {
                  Get.to(
                      ProjectPage(id: _projectsController.projects[index].id));
                },
                child: Container(
                    child: Text(_projectsController.projects[index].name))),
            separatorBuilder: (context, index) => const Divider(),
            itemCount: _projectsController.projects.length);
      }),
    );
  }
}
