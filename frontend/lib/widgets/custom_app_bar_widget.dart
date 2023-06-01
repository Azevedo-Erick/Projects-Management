import 'package:flutter/material.dart';

class CustomAppBarWidget extends StatelessWidget
    implements PreferredSizeWidget {
  final Widget body;
  final String name;
  const CustomAppBarWidget({super.key, required this.body, required this.name});

  @override
  Widget build(BuildContext context) {
    return Container(
      width: MediaQuery.of(context).size.width,
      margin: const EdgeInsets.symmetric(horizontal: 11),
      decoration: const BoxDecoration(
          color: Color(0xff1F2937),
          borderRadius: BorderRadius.only(
            bottomLeft: Radius.circular(16),
            bottomRight: Radius.circular(16),
          )),
      padding: const EdgeInsets.only(bottom: 13, left: 13, right: 13, top: 21),
      child: Column(
        children: [
          Row(
            children: [const Icon(Icons.menu_rounded), Text(name)],
          ),
          body
        ],
      ),
    );
  }

  @override
  Size get preferredSize => const Size.fromHeight(kToolbarHeight + 56);
}
