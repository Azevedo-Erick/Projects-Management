import 'package:flutter/material.dart';

class CustomDrawer extends StatelessWidget {
  const CustomDrawer({
    Key? key,
    this.onItemSelected,
  }) : super(key: key);

  final ValueChanged<String>? onItemSelected;

  @override
  Widget build(BuildContext context) {
    return Drawer(
      child: ListView(
        padding: EdgeInsets.zero,
        children: [
          const DrawerHeader(
            decoration: BoxDecoration(
              color: Colors.blue,
            ),
            child: Text(
              'Menu',
              style: TextStyle(
                color: Colors.white,
                fontSize: 24,
              ),
            ),
          ),
          ListTile(
            leading: const Icon(Icons.home),
            title: const Text('Home'),
            onTap: () {
              if (onItemSelected != null) {
                onItemSelected!("Home");
              }
            },
          ),
          ListTile(
            leading: const Icon(Icons.settings),
            title: const Text('Configurações'),
            onTap: () {
              if (onItemSelected != null) {
                onItemSelected!("Configurações");
              }
            },
          ),
          // Adicione botões personalizados aqui
          ListTile(
            leading: const Icon(Icons.add),
            title: const Text('Botão Personalizado 1'),
            onTap: () {
              if (onItemSelected != null) {
                onItemSelected!("Botão Personalizado 1");
              }
            },
          ),
          ListTile(
            leading: const Icon(Icons.add),
            title: const Text('Botão Personalizado 2'),
            onTap: () {
              if (onItemSelected != null) {
                onItemSelected!("Botão Personalizado 2");
              }
            },
          ),
        ],
      ),
    );
  }
}
