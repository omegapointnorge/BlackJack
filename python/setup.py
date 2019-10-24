from setuptools import setup, find_packages

setup(
    name='blackjack',
    version='2019.10.24',
    description='Half-implemented blackjack application',
    author='Øystein Blixhavn',
    author_email='oeb@itverket.no',
    packages=find_packages(),
    include_package_data=True,
    test_suite='tests',
    install_requires=[
    ],
    entry_points={
        'console_scripts': [
            'play=blackjack.program:main',
        ]},
)
