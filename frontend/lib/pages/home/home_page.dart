import 'package:dio/dio.dart';
import 'package:flutter/material.dart';
import 'package:frontend/data/repositories/project_repository.dart';
import 'package:get/get.dart';

import '../../controllers/home_controller.dart';

class HomePage extends StatefulWidget {
  const HomePage({super.key});

  @override
  State<HomePage> createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  late final HomeController _homeController;

  @override
  void initState() {
    super.initState();
    _homeController = HomeController(
      projectRepository: ProjectRepository(
        dio: Dio(),
      ),
    );
    _homeController.getProjects();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text('Projetos')),
      body: Obx(() {
        if (_homeController.isLoading.value) {
          return const CircularProgressIndicator();
        }
        if (_homeController.projects.isEmpty) {
          return const Center(
            child: Text(
              "Não há projetos cadastrados",
            ),
          );
        }

        return ListView.separated(
            itemBuilder: (context, index) => Container(),
            separatorBuilder: (context, index) => const Divider(),
            itemCount: _homeController.projects.length);
      }),
    );
  }
}
