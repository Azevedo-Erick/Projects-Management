import 'package:flutter/material.dart';
import 'package:frontend/stores/configurations_store.dart';
import 'package:frontend/widgets/custom_app_bar_widget.dart';
import 'package:provider/provider.dart';

import '../../widgets/custom_bottom_navigation_bar_widget.dart';
import '../../widgets/custom_drawer.dart';

class ConfigurationsScreen extends StatefulWidget {
  ConfigurationsScreen({super.key});
  int _currentIndex = 0;
  @override
  State<ConfigurationsScreen> createState() => _ConfigurationsScreenState();
}

class _ConfigurationsScreenState extends State<ConfigurationsScreen> {
  @override
  Widget build(BuildContext context) {
    final ConfigurationsStore configurationsStore =
        Provider.of<ConfigurationsStore>(context);
    return Scaffold(
      appBar: CustomAppBarWidget(
        body: Container(),
        name: "Configurações",
      ),
      body: Container(
        margin: const EdgeInsets.all(15),
        decoration: BoxDecoration(
          color: Theme.of(context).secondaryHeaderColor,
          borderRadius: BorderRadius.circular(15),
        ),
        child: Column(
          children: [
            RadioListTile(
              value: ThemeMode.system,
              groupValue: configurationsStore.themeMode,
              title: const Text('Sistema'),
              onChanged: (ThemeMode? value) {
                configurationsStore.switchTheme(value);
              },
            ),
            RadioListTile(
              value: ThemeMode.light,
              groupValue: configurationsStore.themeMode,
              title: const Text('Claro'),
              onChanged: (ThemeMode? value) {
                configurationsStore.switchTheme(value);
              },
            ),
            RadioListTile(
              value: ThemeMode.dark,
              groupValue: configurationsStore.themeMode,
              title: const Text('Escuro'),
              onChanged: (ThemeMode? value) {
                configurationsStore.switchTheme(value);
              },
            ),
          ],
        ),
      ),
      bottomNavigationBar: CustomBottomNavigationBar(
        currentIndex: widget._currentIndex,
        onTap: (index) {
          // Lógica para lidar com a mudança de índice
          setState(() {
            widget._currentIndex = index;
          });
        },
      ),
      drawer: const CustomDrawer(),
    );
  }
}
