import 'package:flutter/material.dart';
import 'package:frontend/stores/configurations_store.dart';
import 'package:frontend/widgets/custom_app_bar_widget.dart';
import 'package:provider/provider.dart';

class ConfigurationsScreen extends StatefulWidget {
  const ConfigurationsScreen({super.key});

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
      body: Column(children: [
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
      ]) /*  Radio(value: value, groupValue: groupValue, onChanged: onChanged) */,
    );
  }
}
